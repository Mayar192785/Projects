const {Router} = require("express");
const filecontroller = require("../controllers/files");
const filerouter = Router();

filerouter.post('/upload', filecontroller.postfile);
// filerouter.get('/', filecontroller.getListFiles);
// filerouter.get('/files/:name', filecontroller.download);


module.exports = filerouter;