const {Schema,model}= require("mongoose");

const UserSchema = new Schema({
    email:{
        type: String,
        required:true,
        trim:true
    },
    username:{
        type: String,
        required:true
    },
    password:{
        type: String,
        required:true
    },
    role:{
        type: String,
        default: "basic",
        enum:["basic","auditor","admin"]
    },
    accessToken:{
        type: String
    },

});

module.exports= new model('User',UserSchema);
