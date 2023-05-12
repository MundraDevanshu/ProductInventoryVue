<template>
 <div class="nav-bar">
    <div class="title">Product Inventory</div>
    <ul class="top-nav">
        <li>
            {{ message }}
        </li>        
        <li>
        <a href='/'>Logout</a>
        </li>
    </ul>
</div>
</template>

<script>
export default {
    name:'Nav',
    props: {
        message: {
            type: String,
            required: true
        }
}
}
</script>

<style>

</style>