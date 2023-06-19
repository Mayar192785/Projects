const {Schema,model}= require("mongoose");
 
var AuditTrailSchema = new Schema(
    {
        userID:String,
        fileID:String,
        fakeobject: String,
        action:String,

    },
    {
        timestamps:true
    }
);
 
module.exports = new model('AuditTrail', AuditTrailSchema);
