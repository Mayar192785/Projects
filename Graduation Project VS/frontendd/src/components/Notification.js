import React, { useState, useEffect } from 'react';

function EmailNotificationPage() {
    const [data, setData] = useState([]);
    const [numNotifications, setNumNotifications] = useState(0);

  useEffect(() => {
    const fetchData = async () => {
      // Fetch the data from the server
      const response = await fetch('http://localhost:3001/Notification');
      const data = await response.json();
      setData(data);
      setNumNotifications(data.length);
    };
    fetchData();
  }, []);
  useEffect(() => {
    const interval = setInterval(() => {
      // Check if any notifications have fallen below their threshold
      const newData = data.map((item) => {
        if (item.value < item.threshold) {
          return {
            ...item,
            value: item.value + 1,
          };
        }
        return item;
      });
      setData(newData);

      // Add a new notification if necessary
      const shouldAddNotification = Math.random() < 0.2;
      if (shouldAddNotification) {
        const newNotification = {
          name: 'New Notification'
        };
        setData([...newData, newNotification]);
        setNumNotifications(numNotifications + 1);
      }
    }, 3000);
    return () => clearInterval(interval);
  }, [data, numNotifications]);

  const handleRemoveNotification = (name) => {
    const filteredData = data.filter((item) => item.name !== name);
    setData(filteredData);
    setNumNotifications(numNotifications - 1);
  };

  return (
    <div className="flex justify-center mt-8">
      <div className="flex flex-col ">
    

          Notifications ({numNotifications})
        { data.length>0
        && data.map((item) => (
          <div key={item.name} className="max-w-2xl rounded-lg shadow-xl bg-gray-50 m-4 bg-red-600">
            <div className="p-4 flex items-center">
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                strokeWidth="1.5"
                stroke="white"
                className="w-6 h-6 mr-2 text-red-500"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  d="M11.25 11.25l.041-.02a.75.75 0 011.063.852l-.708 2.836a.75.75 0 001.063.853l.041-.021M21 12a9 9 0 11-18 0 9 9 0 0118 0zm-9-3.75h.008v.008H12V8.25z"
                />
              </svg>
              
              <div class="text-white ">
                Threshold exceeded ! Potential Data Leak for the following files : {item.name}
              </div>
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="white" class="w-6 h-6" onClick={() => handleRemoveNotification(item.name)}>
                <path stroke-linecap="round" stroke-linejoin="round" d="M9.75 9.75l4.5 4.5m0-4.5l-4.5 4.5M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
                </svg>

            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default EmailNotificationPage;