export const LocalStorageService = {
    save(key:string, value:string){
        localStorage.setItem(key, value);
    },
    get(key:string): string | null{
        const value = localStorage.getItem(key);
        if(!this.exists(key)){
            console.error("Key does not exists: " + key);
            return null;
        }
        return value;
    },
    remove(key:string){
        localStorage.removeItem(key);
    },
    exists(key:string): boolean{
        const value = localStorage.getItem(key);
        return value != null;
    },
    clear(){
        localStorage.clear()
    }
}