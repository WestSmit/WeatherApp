<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header class="d-flex justify-content-center py-2 bg-light gap-2">
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
      <div class="container-fluid">
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="nav-item">
              <RouterLink class="nav-link" to="/">Search</RouterLink>
            </li>
            <li class="nav-item">
              <RouterLink class="nav-link" to="/history">History</RouterLink>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>


  <RouterView />
</template>

<style scoped>
header {
  padding: 0;
}
</style>
