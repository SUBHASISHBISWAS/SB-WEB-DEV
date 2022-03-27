import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
import { getFirestore, collection, getDocs } from "firebase/firestore/lite";
import { getAuth, onAuthStateChanged } from "firebase/auth";
const firebaseConfig = {
  apiKey: "AIzaSyBUecvPKLc6VDXdpuAHTDzx-ln41G4ukag",
  authDomain: "sb-temperaturecontroller.firebaseapp.com",
  projectId: "sb-temperaturecontroller",
  storageBucket: "sb-temperaturecontroller.appspot.com",
  messagingSenderId: "204321118217",
  appId: "1:204321118217:web:b1e1f0f5369feb4ef800d8",
  measurementId: "G-2SQCPWLVBE",
};

const firebaseApp = initializeApp(firebaseConfig);
const firebaseDb = getFirestore(firebaseApp);
const auth = getAuth(firebaseApp);
onAuthStateChanged(auth, (user) => {
  if (user) {
    console.log("User is logged in");
  } else {
    console.log("User is logged out");
  }
});
export default firebaseDb;
