import React, { useState, useEffect } from "react";


function HistoryFile() {
  const [files, setFiles] = useState([]);

  useEffect(() => {
    fetch("http://localhost:3001/historyfiles")
      .then((res) => res.json())
      .then((data) => setFiles(data))
      .catch((err) => console.log(err));
  }, []);


  return (
    <div className="flex flex-col ml-96 mt-14">
    <div>
        <div className="p-1.5 w-9/12  ">
            <div className="overflow-hidden border rounded-lg">
                <table className="min-w-full divide-y divide-gray-200">
                    <thead className="bg-gray-50">
                        <tr>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-left text-gray-500 uppercase "
                            >
                                ID
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-left text-gray-500 uppercase "
                            >
                                Name
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-right text-gray-500 uppercase "
                            >
                                Date/Time of Upload
                            </th>
                        </tr>
                    </thead>
                    <tbody className="divide-y divide-gray-200">
                    {files.length > 0 &&
                      files.map((file) => (
                        <tr key={file}>
                            <td className="px-6 py-4 text-sm font-medium text-gray-800 whitespace-nowrap">
                                {files.indexOf(file)}
                            </td>
                            <td className="px-6 py-4 text-sm text-gray-800 whitespace-nowrap">
                              {file.namee}
                            </td>
                            <td className="px-6 py-4 text-sm font-medium text-right whitespace-nowrap text-green-500 hover:text-green-700">
                                {file.DateUpload}  
                            </td>
                        </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
);
}

export default HistoryFile;
