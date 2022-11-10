export const DateService = {
  filteredDates(from: Date, to: Date, dates: Date[]): Array<Date> {
    var validDates: Array<Date> = [];

    for (let i = 0; i < dates.length; i++) {
      const element = dates[i];
      if (
        from.getDate() <= element.getDate() &&
        to.getDate() >= element.getDate()
      ) {
        validDates.push(element);
      }
    }

    return validDates;
  },
  
  validIndexes(from: Date, to: Date, dates: Date[]): Array<number> {
    var validIndexes: Array<number> = [];

    for (let i = 0; i < dates.length; i++) {
      const element = dates[i];
      if (
        from.getDate() <= element.getDate() &&
        to.getDate() >= element.getDate()
      ) {
        validIndexes.push(i);
      }
    }

    return validIndexes;
  },
  

  convertDateToString(){
    

  }
};
