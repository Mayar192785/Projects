const {Schema,model, SchemaTypes}= require("mongoose");

var fileSchema = new Schema({
    UploadingUser: [{type: SchemaTypes.ObjectId, ref:'User'}],
    files:[{
        namee: String,
        img:
        {
            data: Buffer,
            contentType: String
        },
        fakeObject: String,
        DateUpload: String

    }]
});
 
module.exports = new model('File', fileSchema);
