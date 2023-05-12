<template>
   <div class="sidebar">
    <ul class="side-menu">
        <li><router-link :to="{ name: 'Pagination'}"> <fa
                  style="
                    background-color: transparent;
                    color: black;
                    padding-top: 10px;
                    padding-right: 5px;
                    
                  "
                  icon="list"
                ></fa>ProductList</router-link></li>
        <li><router-link :to="{ name: 'ProductCreate'}"><fa
                  style="
                    background-color: transparent;
                    color: black;
                    padding-top: 5px;
                    padding-right: 5px;
                  "
                  icon="add"
                ></fa>Add Product</router-link></li>
    </ul>
</div>
</template>

<script>
export default {
    name:'Sidebar'

}
</script>

<style>

</style>