const express = require('express');
const path = require('path');
const app = express();

app.use(express.static(path.join(__dirname, '/../build')));
console.log(path.join(__dirname, '/../build'));

const port = process.env.PORT || 3000;
app.listen(port, () =>
  console.log(`Example app listening on port ${port}!`));

