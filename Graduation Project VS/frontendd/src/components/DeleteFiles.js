import React, { useState, useEffect } from "react";
import {Routes, Route, useNavigate} from 'react-router-dom';
function RecycleBin() {


  return (
    <div className="flex flex-col ml-96 mt-14">
    <div>
        <div className="flex justify-between py-3 pl-2">

            <div className="flex items-center space-x-2 mr-72">
                <div className="">
                    <button className=" z-0 inline-flex text-sm rounded-md shadow-sm focus:ring-accent-500 focus:border-accent-500 hover:bg-gray-50 focus:z-10 focus:outline-none focus:ring-1">
                        <span className=" inline-flex items-center px-3 py-3 space-x-2 text-sm font-medium text-gray-600 bg-white border border-gray-300 rounded-md sm:py-2">
                            <div>
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    className="w-3 h-3"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                    strokeWidth={2}
                                >
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        d="M3 4a1 1 0 011-1h16a1 1 0 011 1v2.586a1 1 0 01-.293.707l-6.414 6.414a1 1 0 00-.293.707V17l-4 4v-6.586a1 1 0 00-.293-.707L3.293 7.293A1 1 0 013 6.586V4z"
                                    />
                                </svg>
                            </div>
                            <div className="hidden sm:block">
                                Filters
                            </div>
                        </span>
                    </button>
                </div>
            </div>
        </div>

        <div className="p-1.5 w-9/12  ">
            <div className="overflow-hidden border rounded-lg">
                <table className="min-w-full divide-y divide-gray-200">
                    <thead className="bg-gray-50">
                        <tr>
                            <th scope="col" className="py-3 pl-4">
                                <div className="flex items-center h-5">
                                    <input
                                        id="checkbox-all"
                                        type="checkbox"
                                        className="text-blue-600 border-gray-200 rounded focus:ring-blue-500"
                                    />
                                    <label
                                        htmlFor="checkbox"
                                        className="sr-only"
                                    >
                                        Checkbox
                                    </label>
                                </div>
                            </th>
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
                                Expiry Duration
                            </th>
                            <th
                                scope="col"
                                className="px-6 py-3 text-xs font-bold text-right text-gray-500 uppercase "
                            >
                                Delete
                            </th>
                        </tr>
                    </thead>
                    <tbody className="divide-y divide-gray-200">
                    {/* {files.length > 0 &&
                      files.map((file) => ( key={file}*/}

                        <tr >
                            <td className="py-3 pl-4">
                                <div className="flex items-center h-5">
                                    <input
                                        type="checkbox"
                                        className="text-blue-600 border-gray-200 rounded focus:ring-blue-500"
                                    />
                                    <label
                                        htmlFor="checkbox"
                                        className="sr-only"
                                    >
                                        Checkbox
                                    </label>
                                </div>
                            </td>
                            <td className="px-6 py-4 text-sm font-medium text-gray-800 whitespace-nowrap">
                                {/* {files.indexOf(file)} */}
                            </td>
                            <td className="px-6 py-4 text-sm text-gray-800 whitespace-nowrap">
                              {/* {file} */}
                            </td>
                            <td className="px-6 py-4 text-sm font-medium text-right whitespace-nowrap text-green-500 hover:text-green-700">
                                
                                    
                            </td>
                            <td className="px-6 py-4 text-sm font-medium text-right whitespace-nowrap text-red-500 hover:text-red-700">
                                   <button >Permentaly Delete </button> 
                            </td>
                        </tr>
                        {/* ))} */}
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
);
}

export default RecycleBin;
