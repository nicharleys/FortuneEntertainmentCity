const express = require('express')
const bodyParser = require('body-parser')
const app = express()
const port = 3000

app.use(bodyParser.json({type: '*/*'}))

app.post('/download', (req, res) => {
  var userInfo = { Account: 'xcv', password: 'hbedrh' };
  res.send(userInfo)
})
app.post('/upload', (req, res) => {
  console.log(req.body);
})
app.post('/LoginAccount', (req, res) => {
  console.log(req.body);
  console.log("登入帳號");
  res.send("1");
})
app.post('/ForgotPassword', (req, res) => {
  console.log(req.body);
  console.log("發送密碼至信箱");
  res.send("0");
})
app.post('/SendVerification', (req, res) => {
  console.log(req.body);
  console.log("發送驗證");
  res.send("1");
})
app.post('/CreateAccount', (req, res) => {
  console.log(req.body);
  console.log("新增帳號");
  res.send("1");
})
app.listen(port, () => {
  console.log(`Listening at http://localhost:${port}`);
})