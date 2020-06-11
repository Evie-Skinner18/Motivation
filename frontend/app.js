"use strict";


var todaysDate = new Date();
var today = todaysDate.getDay();

var headers = new Headers();
headers.append('Origin','http://localhost:5500');

var motivationUrl = `https://localhost:5001/api/messages/${today}`;
console.log(motivationUrl);

// fetch handlebars template and .compile it
// fetch API data and .json it
fetch(`${motivationUrl}`, { headers: headers }).then(function (jsonData) {
    jsonData = jsonData.json();
    var responseBody = jsonData.body;
    console.log(responseBody);
  return responseBody;
}).then(function (motivationApiData) {
  fetch('template.hbs').then(function (handlebarsTemplateData) {
    return handlebarsTemplateData.text();
  }).then(function (messageTemplate) {
    var htmlTemplate = Handlebars.compile(messageTemplate);
    var todaysMessage = {};

    //todaysMessage.items = githubApiData.items.slice(0,6);
    var todaysMessageInHtml = htmlTemplate(todaysMessage);
    document.querySelector('.message').innerHTML = todaysMessageInHtml;
  });
});