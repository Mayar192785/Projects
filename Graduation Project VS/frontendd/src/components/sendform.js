import React, { useState } from "react";

const FORM_ENDPOINT = ""; // TODO - fill on the later step
function Sendform(){

        const [submitted, setSubmitted] = useState(false);
        const handleSubmit = () => {
          setTimeout(() => {
            setSubmitted(true);
          }, 100);
        };
      
        if (submitted) {
          return (
            <>
              <div className="text-2xl">Thank you!</div>
              <div className="text-md">We'll be in touch soon.</div>
            </>
          );
        }
      
        return (
            <div className=" absolute inset-y-0 right-0  py-5 px-4 sm:px-6 lg:px-8 mr-20">
                <h1 class=" text-4xl mt-8 text-center italic text-sky-600">Request File</h1>
          <form
            action={FORM_ENDPOINT}
            onSubmit={handleSubmit}
            method="POST"
            target="_blank"
          >
            <div className="mb-3 mt-8">
              <input
                type="text"
                placeholder="Your name"
                name="name"
                className="px-12 py-3 placeholder-gray-400 text-gray-600 relative bg-white bg-white rounded text-sm border-0 shadow outline-none focus:outline-none focus:ring "
                required
              />
            </div>
            <div className="mb-3 pt-0">
              <input
                type="email"
                placeholder="Reciever Email"
                name="email"
                defaultValue={"mayar@gmail.com"}
                disabled="false"
                className="px-12 py-3 placeholder-gray-400 text-gray-600 relative bg-white bg-white rounded text-sm border-0 shadow outline-none focus:outline-none focus:ring "
                required
              />
            </div>
            <div className="mb-3 pt-0">
              <textarea
                placeholder="Your message"
                name="message"
                className="px-12 py-3 placeholder-gray-400 text-gray-600 relative bg-white bg-white rounded text-sm border-0 shadow outline-none focus:outline-none focus:ring "
                required
              />
            </div>
            <div className="mb-3 pt-0">
              <button
                className="bg-sky-600 text-white active:bg-blue-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
                type="submit"
              >
                Send a request
              </button>
            </div>
          </form>
          
          </div>
          
        );

};


export default Sendform;