export class DataProviderService {
    static getContacts() {
        return JSON.parse(window.localStorage.getItem('contacts'));
    }
    static getContact(id) {
        let data = JSON.parse(window.localStorage.getItem('contacts'));
        for (let i of data) {
            if (i.id == id) {
                return i;
            }
        }
    }
    static updateContacts(data) {
        window.localStorage.setItem("contacts", JSON.stringify(data));
    }
    static getFirstId() {
        let data = JSON.parse(window.localStorage.getItem('contacts'));
        return data[0].id;
    }
    static getPreviousId(id) {
        let data = JSON.parse(window.localStorage.getItem('contacts'));
        if (data[0].id == id && data.length > 1)
            return data[1].id;
        for (let i = 0; i < data.length - 1; i++) {
            if (data[i + 1].id == id) {
                return data[i].id;
            }
        }
        return "";
    }
}
