import React, { useState } from "react";
import axios from "axios";

export default function FileUpload(){
  const [fileData,setFileData] = useState("");

  const getFile = (e) => {
    setFileData(e.target.files[0]);
  };

  const uploadFile = (e) => { 
    e.preventDefault();   
    const data = new FormData();
    data.append("file", fileData);
    axios({
      method: "POST",
      url: "http://localhost:3001/upload",
      data: data,
    }).then((res) => {       
      console.log("Response:", res);
      alert("File uploaded successfully");
    }).catch((err) => {
      console.log("Error:", err);
      alert("Error uploading file");
    });
  };
  
  const removeFile = (e) => {
    setFileData("");
  };



  return(
    <div class="flex justify-center mt-8 ">
      <div class="max-w-2xl rounded-lg shadow-xl bg-gray-50">
        <div class="m-4">
          <div class="flex justify-center p-2">
            <form onSubmit={uploadFile}>
              <input type="file" name="file" onChange={getFile} />
              <input type="submit" name="upload" value="Upload" class="bg-sky-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded" />
            </form>
            <input type="submit" name="remove" value="Remove" class="bg-sky-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded ml-5" onClick={removeFile} />
          </div>
        </div>
      </div>
    </div> 
  )
}
