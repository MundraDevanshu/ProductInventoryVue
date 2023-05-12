<template>

  <router-view/>
</template>

<style>
* {
  margin: 0;
  padding: 0;
}
body {
  font-family: Arial, Helvetica, sans-serif;
  height: 100%;
}
ul {
  list-style: none;
}
.nav-bar {
  background-color: #343a40;
  display: flex;
  justify-content: space-between;
  align-items: center;
  color: white;
}
.nav-bar a {
  color: white;
}
.top-nav li {
  display: inline-block;
  padding: 15px 15px 15px 0px;
}
.title {
  padding-left: 15px;
  font-size: 20px;
}
.wrraper {
  display: flex;
}
.left-content {
  background-color: #f8f9fa;
  flex: 2;
  min-height: 90vh;
}
.side-menu {
  margin-top: 20px;
}
.side-menu li {
  border-bottom: dashed 1px #cfd3d8;
}
.side-menu a {
  display: block;
  padding: 10px 15px;
  color: #343a40;
  text-decoration: none;
}
.right-content {
  padding: 20px;
  flex: 9;
}
.input-group{
  margin:1%;
}

.btn_space{
  padding: 0px 10px;
  border:  2px solid turquoise;
}

.my-custom-scrollbar {
position: relative;
height: 400px;
overflow: auto;
}
.table-wrapper-scroll-y {
display: block;
}
.table>thead{
  text-align:center;
}
.table>tbody{
  text-align:center;
}
form {
  max-width: 450px;
  width: 100%;
  margin: auto;
}
label {
  display: block;
  font-size: 18px;
  margin-top: 15px;
  line-height: 30px;
}
input {
  display: block;
  width: 100%;
  height: 35px;
  border: turquoise 2px solid;
  margin-bottom: 10px;
  padding-left: 10px;
}
.edit_icon , .delete_icon{
  color: whitesmoke;
  padding: 5px;
  margin: 2px;
}
.edit_icon{
  background-color: blue;
}
.delete_icon{
  background-color: red;
}
.not_found{
  text-align: center; 
}
.pgn_btn{
  margin: 2px; 
  padding: 3px;
}


</style>
