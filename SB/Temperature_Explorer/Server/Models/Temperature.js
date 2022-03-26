class City {
  constructor(capital, country, name, population, regions) {
    this.name = name;
    this.capital = capital;
    this.country = country;
    this.population = population;
    this.regions = regions;
  }
  toString() {
    return (
      this.name +
      ", " +
      this.capital +
      ", " +
      this.country +
      ", " +
      this.population +
      ", " +
      this.regions
    );
  }
}

export const cityConverter = {
  toFirestore: (city) => {
    return {
      name: city.name,
      capital: city.capital,
      country: city.country,
      population: city.population,
      regions: city.regions,
    };
  },
  fromFirestore: (snapshot, options) => {
    const data = snapshot.data(options);
    return new City(
      data.capital,
      data.country,
      data.name,
      data.population
      //this.regions
    );
  },
};
export default City;
