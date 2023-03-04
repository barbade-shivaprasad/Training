let baseUrl = "https://localhost:7185/addressbook";
export class DataProviderService {
    static async getContacts() {
        let res = await fetch(`${baseUrl}/getcontactlist`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });
        let data = await res.json();
        return data;
    }
    static async getContact(id) {
        let res = await fetch(`${baseUrl}/getcontact/${id}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            },
        });
        let data = await res.json();
        return data;
    }
    static async updateContact(contact) {
        let res = await fetch(`${baseUrl}/editContact/${contact.id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(contact)
        });
        let data = await res.text();
        return data;
    }
    static async addContact(contact) {
        let res = await fetch(`${baseUrl}/addcontact/`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(contact)
        });
        let data = await res.text();
        return data;
    }
    static async getPreviousId(id) {
        try {
            let res = await fetch(`${baseUrl}/getpreviousid/${id}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                }
            });
            let data = await res.text();
            if (!Number.isNaN(Number(data)))
                return data;
            return "";
        }
        catch (err) {
            console.log(err);
        }
    }
    static async deleteContact(id) {
        try {
            let res = await fetch(`${baseUrl}/deletecontact/${id}`, {
                method: "DELETE",
                headers: {
                    "Content-Type": "application/json"
                }
            });
            let data = await res.text();
            return data;
        }
        catch (err) {
            console.log(err);
        }
    }
}
