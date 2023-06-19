const { Router } = require('express');

const userController = require('../controllers/users');

const UserRouter = Router();

UserRouter.post('/login', userController.postLogin);

UserRouter.get('/:userId', userController.allowIfLoggedin, userController.getUser);
 
UserRouter.get('/',  userController.getUsers);
 
UserRouter.put('/user/:userId', userController.allowIfLoggedin, userController.grantAccess('updateAny', 'profile'), userController.updateUser);
 
UserRouter.delete('/user/:userId', userController.allowIfLoggedin, userController.grantAccess('deleteAny', 'profile'), userController.deleteUser);

module.exports=UserRouter;
