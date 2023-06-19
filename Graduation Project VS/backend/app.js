const express = require('express');
const dotenv = require('dotenv');
const initiateDBConnection = require('./config/db');
const UserService=require("./services/users")
const UserModel = require('./models/User');
const bodyParser = require("body-parser");
const path = require('path');
const fs = require('fs');
const multer = require('multer');
const fileModel = require('./models/File');
const app = express();
const cors = require('cors');
const logModel=require('./models/AuditTrail');
const { join } = require('path');
const {spawn}= require("child_process");
const chokidar = require('chokidar');
const nodemailer = require('nodemailer');
const JSONStream = require('JSONStream');

dotenv.config({
  path: './config/.env'
});

app.use(express.json());
app.use(cors());



let username="may20";
app.post("/users/login",async(req,res,next)=>{
    try {
      username = req.body.username;
      const {password}= req.body;
      const user = await UserService.checkCredentials(username,password);
      if (!user) {
        return res.status(401).send({
          error:
            'Invalid credentials, please enter the correct username and password.'
        });
      }
      
      const jwt = await UserService.generateJWT(user);
      const message = 'Logged in successfully.';
      const role= user.role;
      res.status(200).send({message,role});
      createLog(username,"no file","no fake object","logged in");
    } catch (err) {
      res.status(500).send({
        error: err.message
      });
    }
})

app.use(bodyParser.urlencoded(
  { extended:true }
))

app.set("view engine","ejs");

var storage = multer.diskStorage({
  destination: async function (req, file, cb) {
    const exfile = await fileModel.findOne({files:{
      namee: file.originalname}});
    if(!exfile){
      cb(null, 'uploads')
    }else{
      console.log("Fle already exists")
    }
    
  },
  filename: function (req, file, cb) {
    cb(null, file.originalname)
  }
})

var upload = multer({ storage: storage })

app.get("/",(req,res)=>{
  res.render("index");
})

app.post("/upload",upload.single("file"),async (req,res)=>{
  const userrr= username;
  const filepath=req.file.path;
  const unique = Math.random().toString(36).substring(2, 6);
  const userInfo = await UserModel.findOne({username:userrr});
  const uuser= await fileModel.findOne({UploadingUser: userInfo._id});
  addRandomObject(filepath,unique,(err)=>{
    if(err){
      console.log(err);
      return res.status(500).send({message:"Error adding fake object to file"});
    }
  })
  var img = fs.readFileSync(req.file.path);
  var encode_img = img.toString('base64');
  if(uuser){
    uuser.files.push({
      namee: req.file.originalname,
      img:{
        contentType:req.file.mimetype,
        image:new Buffer(encode_img,'base64')
      },
      fakeObject:unique,
      DateUpload: new Date()
    })
    uuser.save();
    res.send({message: "File uploaded successfully"})
  }
  else{
    var final_img = {
      UploadingUser: userInfo._id,
      files:{
        namee: req.file.originalname,
        img:{
          contentType:req.file.mimetype,
          image:new Buffer(encode_img,'base64')
        },
        fakeObject:unique,
        DateUpload: new Date()
    }
  };
    fileModel.create(final_img,function(err,result){
       if(err){
           console.log(err);
             res.status(500).send({message: "Error saving file to database"});
             createLog(userrr,final_img.files.namee,final_img.files.fakeObject,"failed to upload");
        } else {
            console.log("Saved To database");
            res.send({
              message: "File uploaded successfully",
              fileName: req.file.originalname,
            });
            createLog(userrr,final_img.files.namee,final_img.files.fakeObject,"uploaded"); 
        }
    });
  }
 
    createFolder(userrr,req.file.originalname);
});
// app.post("/deletefile",async(req,res,next)=>{
//   //const file= req.body;
//   const use = await UserModel.findOne({username:"may20"});
//   const deletee= await fileModel.findById(
//     { 
//       UploadingUser: use._id
//   });
//   await deletee.files.id(use._id).remove({namee:"file1.txt"})
//  console.log(deletee)

  
// })
// function Expire()
// {
//   // Get the current date and time
//   var rightNow = new Date();
//   // Setup End Date
//   var rightNow = new Date();
//   let expiry  = set

//   if (this.getField("ExtraThree").value!="Off")
//   endDate = new Date("December 15, 2015 1:57:00 PM");

//   if (this.getField("ExtraYear").value!="Off")
//   endDate = new Date("December 31, 2016 1:57:00 PM");

//   if (rightNow < beginDate || rightNow > endDate)
//   {
//     app.alert("I hope you enjoyed using this document.\n\nThe evaluation period has ended.", 0, 0);
//     this.closeDoc(true)
//   }
// }
function addRandomObject(filepath,unique,callback){
  fs.readFile(filepath,"utf8",function(err,data){
    if(err){
      return callback(err);
    }
    fs.appendFile(filepath,unique,"utf8",function (err){
      if(err){
        return callback(err);
      }
      console.log("Fake object added successfully");
      callback(null);
    })
  })
}

function createLog(userID, fileID,fakeobject,action){
    const logsDirectory = path.join(__dirname,'logs');

    if(!fs.existsSync(logsDirectory)){
        fs.mkdirSync(logsDirectory);
    }
    const logEntry = `${new Date().toISOString}-User ${userID} Action ${action} File ${fileID} Fake Object ${fakeobject} `;
    const logFile= path.join(logsDirectory,'audit.log');

    fs.appendFile(logFile,logEntry,(err)=>{
        if(err){
            console.log(`Failed to write to log file:${err}`);
        }
          var log= {
            userID:userID,
            fileID: fileID,
            fakeobject:fakeobject,
            action:action,
            timestamps: new Date()
          }
          logModel.create(log);
        
    })
}

function createFolder(username,file){
  const directory = `uploads/${username}`;
    if(!fs.existsSync(directory)){
      fs.mkdirSync(directory,{mode:'0777'});
      fs.cp(`uploads/${file}`,`uploads/${username}/${file}(1)`,(err) => err && console.error(err));
    }else{
      fs.cp(`uploads/${file}`,`uploads/${username}/${file}(1)`,(err) => err && console.error(err));
    }
    console.log("done");
}
app.post("/addusesr",async(req,res)=>{
  var newuser = {
    email: req.body.email,
    username:req.body.username,
    password:req.body.password,
    role: req.body.role
  }
  const find = UserService.doesUserExist(newuser.username)
  if(find){
    UserModel.create(newuser)
           console.log("Saved To database");
           res.send({
             message: "User added successfully",
             role: req.body.role
           });
  }
  else{
    res.send({
      message: "Username is already available"
    });
  }
});
  
app.get("/users", async (req, res) => {
  const userrs = await UserModel.find({role:"basic"}).select({_id:0})
  let uarray=[];
  for(let i of userrs){
    uarray.push({
      email:i.email,
      username:i.username,
    });
  }
  res.send(uarray);

  });
  app.get("/empfiles",(req,res)=>{
    const name= username;
    const dir = `uploads/${name}`;
    const files= fs.readdirSync(dir);
    files.indexOf(`${name}`);
    let file=[]
    for(let i of files){
      file.push(i.split("(1)").join(""));
    }
    res.send(file);
  });

  app.get("/historyfiles",async (req,res)=>{
    const name= username;
    const dir = `uploads/${name}`;
    const files= fs.readdirSync(dir);
    files.indexOf(`${name}`);
    const userInfo = await UserModel.findOne({username:name});

    let file=[]
    for(let i of files){
      const date = await fileModel.findOne({
        UploadingUser: userInfo._id,
        files:{
          namee: i.split("(1)").join("")
        }
    }).select({DateUpload: 1,_id:0})
    console.log(date)
      file.push({namee:i.split("(1)").join(""),DateUpload: date})
    }
    res.send(file);
  });
  app.get("/logs",(req,res)=>{
    logModel.find(function(err,result){
      if(err){
        console.log(err);
        return res.status(500).send({ message: "No logs are found" });
      }else{
        const logs=[];
        result.forEach((log)=>{
          logs.push({
            userID:log.userID,
            fileID:log.fileID,
            fakeobject:log.fakeobject,
            action:log.action,
            timestamps:log.timestamps
          });
        });
        res.send(logs);
      }
    })
  })

app.get("/home", cors(), async (req, res) => {
	res.send("This is the data for the home page")
})


async function calculateK_anonymity(req, res, next) {
  const directoryPath = path.join(__dirname, `./uploads/may20`);
  const u = await UserModel.findOne({username:"may20"});
  fs.readdir(directoryPath,function (err, filez) {
    if (err) {
        return console.log('Unable to scan directory: ' + err);
    } 
    filez.forEach(async (err)=>{
        const args= await fileModel.findOne({UploadingUser: u._id});
        const search= args.files;
        fs.appendFile(
          join(`./args.json`),
          JSON.stringify(search),
          {
            encoding: 'utf-8',
            flag: 'w',
          },
          (err) => err && console.error(err)
        );
    });
});

const readr= require("./r.json");
if(Object.keys(readr).length===0){
  console.log("hello");
  const pythonP = spawn("python",["./K-anonymity.py", "./args.json","./bar.json","./r.json"]);  
  pythonP.on('close', async () => {
    try {
      const message = "Success";
      console.log(message);
    } catch (err) {
      res.send({ status: 500, message: "Server error"});
    }  
});  
}else{
  const pythonP = spawn("python",["./K-anonymity.py", "./r.json","./bar.json","./r.json"]);  
  pythonP.on('close', async () => {
    try {
      const message = "Success";
      console.log(message);
    } catch (err) {
      res.send({ status: 500, message: "Server error"});
    }  
  });  
}

}

async function calculateTCloseness(req, res) {
  await calculateK_anonymity(req, res);
  
  const pythonProcess = spawn("python", ["./t-closeness.py","main","./r.json","./results.json"]);
  
  pythonProcess.on('close', async () => {
    try {
      const output = "Success";
      return output;
    } catch (err) {
      const output = "Server error";
      res.send({ status: 500, message: "Server error"}); 
      return output;
    }    
  });
}

app.get("/getpoints", async(req, res) => {
    await calculateTCloseness(req, res);  

    const read = require("./results.json");      
    res.json(read );  
  
})

app.get("/getbarpoints",async (req,res)=>{
  await calculateTCloseness();
  const barchart = require("./bar.json");
  res.json(barchart);
})



app.get("/Notification",(req,res)=>{
  const read = require("./results.json");
  let higher =[];
  for (var key in read) {
    if (read.hasOwnProperty(key)) {
      if(read[key]>0.5){
          higher.push({name:key})
      }
    }
  }
  res.send(higher)
})

const PORT = process.env.PORT;

app.listen(PORT, async () => {
  console.log(`Server has been started and is listening to port ${PORT}`);

  await initiateDBConnection();
  
});


