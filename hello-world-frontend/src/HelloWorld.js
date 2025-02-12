import React, { useState, useEffect } from 'react';
import axios from 'axios';

const HelloWorld = () => {
  const [message, setMessage] = useState("");

  useEffect(() => {
    // Gör ett GET-anrop till API:et för att hämta "Hello World"
    axios.get('http://localhost:5164/helloworld') 
      .then(response => {
        setMessage(response.data);  // Uppdatera state med "Hello World"
      })
      .catch(error => {
        console.error("Det gick inte att hämta data", error);
      });
  }, []);

  return (
    <div>
      <h1>{message}</h1>
    </div>
  );
};

export default HelloWorld;
