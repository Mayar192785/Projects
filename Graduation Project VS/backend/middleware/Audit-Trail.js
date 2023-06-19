const AuditTrail = require("../models/AuditTrail");

const logAction=(req,res,next)=>{
    const{userID,fileID,fakeobject,action,timestamp}=req.body;
    const auditTrail= new AuditTrail({
        userID,
        fileID,
        fakeobject,
        action,
        timestamp
    })
    auditTrail.save();
    next();
}

export default logAction;