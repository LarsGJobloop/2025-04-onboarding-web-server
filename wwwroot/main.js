console.log("Script loaded...")

// First querry the server for all quotes
let response = await fetch("/quotes")
let quotes = await response.json()

// Then write them to the Document
let qouteList = document.querySelector("#quotes")

for (let quote of quotes) {
  let newElement = document.createElement("li")
  newElement.textContent = quote.content
  qouteList.append(newElement)
}
