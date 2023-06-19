const UserService = require('../services/users');
const { roles } = require('../roles');

module.exports.postLogin = async (req, res) => {
  // extract the username and password from the request body.
  try {
    const {username,password}= req.body;
    const user = await UserService.checkCredentials(username,password);
    if (!user) {
      return res.status(401).send({
        error:
          'Invalid credentials, please enter the correct username and password.'
      });
    }
    
    const jwt = await UserService.generateJWT(user);
    res.send({
      userId: user._id,
      username: user.username,
      role:user.role,
      accesstoken:user.accesstoken,
      jwt:jwt,
      message: 'Logged in successfully.'
    });
    
  } catch (err) {
    res.status(500).send({
      error: err.message
    });
  }
};

// module.exports.getUsers = async (req, res) => {
//   const users = await UserService.find();
//   res.status(200).json({
//    data: users
//   });
//  }
 module.exports.getUsers = async (req, res) => {
  try {
    const users = await UserService.AllUsers();
    return res.send({ users });
  } catch (err) {
    res.status(500);
    return res.send({
      error: err.message
    });
  }
};

  
 module.exports.getUser = async (req, res, next) => {
  try {
   const userId = req.params.userId;
   const user = await UserService.UserOne(userId);
   if (!user) return next(new Error('User does not exist'));
    res.status(200).json({
    data: user
   });
  } catch (error) {
   next(error)
  }
 }
  
 module.exports.updateUser = async (req, res, next) => {
  try {
   const update = req.body
   const userId = req.params.userId;
   await UserService.findByIdAndUpdate(userId, update);
   const user = await UserService.findById(userId)
   res.status(200).json({
    data: user,
    message: 'User has been updated'
   });
  } catch (error) {
   next(error)
  }
 }
  
 module.exports.deleteUser = async (req, res, next) => {
  try {
   const userId = req.params.userId;
   await UserService.findByIdAndDelete(userId);
   res.status(200).json({
    data: null,
    message: 'User has been deleted'
   });
  } catch (error) {
   next(error)
  }
 }

 
module.exports.grantAccess = function(action, resource) {
 return async (req, res, next) => {
  try {
   const permission = roles.can(req.user.role)[action](resource);
   if (!permission.granted) {
    return res.status(401).json({
     error: "You don't have enough permission to perform this action"
    });
   }
   next()
  } catch (error) {
   next(error)
  }
 }
}
 
module.exports.allowIfLoggedin = async (req, res, next) => {
 try {
  const user = res.locals.loggedInUser;
  if (!user)
   return res.status(401).json({
    error: "You need to be logged in to access this route"
   });
   req.user = user;
   next();
  } catch (error) {
   next(error);
  }
}
