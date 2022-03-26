import firebaseDb from "../config.js";
import { cityConverter } from "../models/Temperature.js";
import City from "../models/Temperature.js";
import {
  getFirestore,
  collection,
  getDocs,
  setDoc,
  doc,
  query,
  where,
} from "firebase/firestore/lite";

var getTemperature = (req, res, next) => {
  console.log("Server Connected");

  getCities(firebaseDb)
    .then((cities) => {
      console.log(cities);
      if (cities) {
        res.status(200).json({
          message: "Cities fetched successfully!",
          cities: cities,
        });
      } else {
        res.status(404).json({
          message: "Cities not found!",
        });
      }
    })
    .catch((err) => {
      console.log(err);
    });
};

async function getCity(firebaseDb) {
  const ref = doc(firebaseDb, "cities", "BJ").withConverter(cityConverter);
  const docSnap = await getDoc(ref);
  console.log(docSnap);
  if (docSnap.exists()) {
    console.log("docSnap");
    // Convert to City object
    const city = docSnap.data();
    // Use a City instance method
    console.log(city.toString());
  } else {
    console.log("No such document!");
  }
}

async function getSpecificCity(firebaseDb) {
  const q = query(
    collection(firebaseDb, "cities"),
    where("capital", "==", true)
  );

  const querySnapshot = await getDocs(q);
  querySnapshot.forEach((doc) => {
    console.log(doc.id, " => ", doc.data());
  });
}

async function getCities(firebaseDb) {
  const citiesCol = collection(firebaseDb, "cities").withConverter(
    cityConverter
  );
  const citySnapshot = await getDocs(citiesCol);
  const cityList = citySnapshot.docs.map((doc) => doc.data());
  return cityList;
}

async function setCities(firebaseDb) {
  const citiesRef = collection(firebaseDb, "cities");

  await setDoc(doc(citiesRef, "SF"), {
    name: "San Francisco",
    state: "CA",
    country: "USA",
    capital: false,
    population: 860000,
    regions: ["west_coast", "norcal"],
  });
  await setDoc(doc(citiesRef, "LA"), {
    name: "Los Angeles",
    state: "CA",
    country: "USA",
    capital: false,
    population: 3900000,
    regions: ["west_coast", "socal"],
  });
  await setDoc(doc(citiesRef, "DC"), {
    name: "Washington, D.C.",
    state: null,
    country: "USA",
    capital: true,
    population: 680000,
    regions: ["east_coast"],
  });
  await setDoc(doc(citiesRef, "TOK"), {
    name: "Tokyo",
    state: null,
    country: "Japan",
    capital: true,
    population: 9000000,
    regions: ["kanto", "honshu"],
  });
  await setDoc(doc(citiesRef, "BJ"), {
    name: "Beijing",
    state: null,
    country: "China",
    capital: true,
    population: 21500000,
    regions: ["jingjinji", "hebei"],
  });
}

export default getTemperature;
