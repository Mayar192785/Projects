import  {
  LineChart,
  ResponsiveContainer,
  Legend, Tooltip,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  ReferenceLine
} from "recharts";
import React, { useState, useEffect } from "react";


function Graph(){

  const [data, setdata] = useState([]);

  useEffect(() => {
    fetch("http://localhost:3001/getpoints")
      .then((res) => res.json())
      .then((data) => setdata(data))
      .catch((err) => console.log(err));
  }, []);




function getdata() {
  const values = [];
  for (const [key, value] of Object.entries(data)) {
  values.push({
  name: key,
  similarity_threshold: value,
  });
  }
  return values;
  }

const pdata= getdata();


  return (
    <div class="w-8/12 h-5/6 mr-96 ml-96 mt-32">
      <h1>Data Leak Chart</h1>
      <ResponsiveContainer aspect={2.5}>
        <LineChart data={pdata}>
            <XAxis dataKey= "name"
            interval={'preserveStartEnd'} />
            <YAxis type="number" domain={[0, 1]}></YAxis>
            <Legend />
            <Tooltip />
            <CartesianGrid />
            <ReferenceLine y={0.5} label="Max" stroke="red" strokeDasharray="3 3" />
            <Line dataKey="similarity_threshold" isAnimationActive={false}
            stroke="#055C9D" activeDot={{ r: 8 }} />
        </LineChart>
      </ResponsiveContainer>
      <h1 class="mt-16 ml-16 text-red-600 pb-12">*** Note: if the file exceeds the threshold, which is shown by the dashed red line, it means that the file is on the verge to be leaked ***</h1>
    </div>
  );
}
export default Graph;