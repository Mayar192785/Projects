import  {
    BarChart,
    XAxis,
    YAxis,
    Bar,
    ResponsiveContainer,
    ReferenceLine
    } from "recharts";
  import React, { useState, useEffect } from "react";
  
  
  function Barchrt(){
  
    const [data, setdata] = useState([]);
  
    useEffect(() => {
      fetch("http://localhost:3001/getbarpoints")
        .then((res) => res.json())
        .then((data) => setdata(data))
        .catch((err) => console.log(err));
    }, []);

  

  function getdata() {
    const values = [];
    for (const [key, value] of Object.entries(data)) {
    values.push({
    name: key,
    k_anonymity: value,
    });
    }
    return values;
    }
  
  const pdata= getdata();
  
  
    return (
      <div class="w-8/12 h-5/6 mr-96 ml-96 mt-32">
        <h1>Bar Chart</h1>
        <ResponsiveContainer aspect={2.5}>
        <BarChart  data={pdata}>
            <Bar dataKey="k_anonymity" fill="#055C9D" />
            <XAxis dataKey="name" />
            <YAxis domain={[0, 7]}/>
            <ReferenceLine y={5} label="Max" stroke="red" strokeDasharray="3 3" />
        </BarChart>
        </ResponsiveContainer>
      </div>
    );
  }
  export default Barchrt;