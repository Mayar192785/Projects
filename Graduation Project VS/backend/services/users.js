const bcrypt = require('bcrypt');
const JWT = require('jsonwebtoken');
const UserModel = require('../models/User');

  module.exports.checkCredentials = async (username,password) => {
    try {
      const user = await UserModel.findOne({
        username:username
      })

     let isCorrectPassword = user.password.match(password);
      if (isCorrectPassword) {
        return user;
      } else {
       return null;
      }
    } catch (error) {
      throw new Error('Error logging in, please try again later.');
    }
  };
  
  module.exports.doesUserExist = async (user) => {
    const existinguser = await UserModel.findOne({
      username: user
    })
  
    if (existinguser) {
      return true;
    } else {
      return false;
    }
  };
  module.exports.generateJWT = (user) => {
    const jwtPayload = {
      userId: user._id,
      username: user.username
    };
  
    const jwtSecret = process.env.JWT_SECRET;
  
    try {
      let token = JWT.sign(jwtPayload, jwtSecret, { expiresIn: '1d' });
      return token;
    } catch (error) {
      throw new Error('Failure to login, please try again later.');
    }
  };
  
  module.exports.auth = async (token) => {
    try {
      const tokenPayload = await JWT.verify(token, process.env.JWT_SECRET);
      return tokenPayload;
    } catch (error) {
      throw new Error('Unauthrozied.');
    }
  };

  module.exports.AllUsers = async () => {
    try {
      const users = await UserModel.find();
      return users;
    } catch (err) {
      throw new Error('Could not retrieve users.');
    }
  };

    module.exports.UserOne = async (id) => {
    try {
      const user = await UserModel.findById({ _id: id });
      return user;
    } catch (err) {
      throw new Error('Could not retrieve user.');
    }
  };