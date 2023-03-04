"use strict";
fetch("https://localhost:7185/addressbook/getcontactlist/", {
    method: "GET",
    headers: {
        "Content-Type": "application/json"
    }
})
    .then((response) => response.json())
    .then((data) => {
    console.log("Success:", data);
})
    .catch((error) => {
    console.error("Error:", error);
});
