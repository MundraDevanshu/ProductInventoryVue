<template>
  <Nav message="Devanshu"></Nav>
  <div class="wrraper">
    <div class="left-content">
      <Sidebar />
    </div>
    <div class="right-content">
      <router-view />
    </div>
  </div>
</template>

<script>
import Nav from "@/components/Nav.vue";
import Sidebar from "@/components/Sidebar.vue";
export default {
  name: "Admin",
  components: { Nav, Sidebar },
 
};
</script>

<style></style>
