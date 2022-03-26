class City {
  constructor(name, state, country) {
    this.name = name;
    this.state = state;
    this.country = country;
  }
  toString() {
    return this.name + ", " + this.state + ", " + this.country;
  }
}

export const cityConverter = {
  toFirestore: (city) => {
    return {
      name: city.name,
      state: city.state,
      country: city.country,
    };
  },
  fromFirestore: (snapshot, options) => {
    const data = snapshot.data(options);
    return new City(data.name, data.state, data.country);
  },
};
export default City;
