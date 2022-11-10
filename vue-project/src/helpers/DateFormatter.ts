const htmlDateAsStringFromat = "yyyy-mm-dd";

export const DateFormatter = {
  dateToString(date: Date, format = htmlDateAsStringFromat):string {
    let ye = new Intl.DateTimeFormat("en", { year: "numeric" }).format(date);
    let mo = new Intl.DateTimeFormat("en", { month: "short" }).format(date);
    let da = new Intl.DateTimeFormat("en", { day: "2-digit" }).format(date);
    return `${da}-${mo}-${ye}`;
  },

  stringToDate(format = htmlDateAsStringFromat) {},
};
