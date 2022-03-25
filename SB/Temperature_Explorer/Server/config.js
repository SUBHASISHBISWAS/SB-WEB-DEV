// Import the functions you need from the SDKs you need
//import { initializeApp } from "firebase/app";
//import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional

const firebase = require("firebase");

const firebaseConfig = {
  apiKey: "AIzaSyBUecvPKLc6VDXdpuAHTDzx-ln41G4ukag",
  authDomain: "sb-temperaturecontroller.firebaseapp.com",
  projectId: "sb-temperaturecontroller",
  storageBucket: "sb-temperaturecontroller.appspot.com",
  messagingSenderId: "204321118217",
  appId: "1:204321118217:web:b1e1f0f5369feb4ef800d8",
  measurementId: "G-2SQCPWLVBE",
};

// Initialize Firebase
const app = firebase.initializeApp(firebaseConfig); //initializeApp(firebaseConfig);
//const analytics = getAnalytics(app);
const db = firebase.firestore();
const Temperature = db.collection("Temperature");
module.exports = TemperatureDb;
