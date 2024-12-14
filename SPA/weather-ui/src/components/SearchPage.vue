<script>
import axios from 'axios'

export default {
  data() {
    return {
      weatherData: null,
      searchString: null
    }
  },
  methods: {
    async search() {
      console.log(this.searchString);
      if (!this.searchString) {
        return
      }
      const searchResults = await axios.get(`http://localhost:5245/api/1/search/${this.searchString}}`)
      this.weatherData = searchResults.data;
      console.log(this.weatherData);
    }
  }
}
</script>

<template>
  <div>
    <form class="d-flex" role="search">
      <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search" v-model="searchString">
      <button class="btn btn-outline-success" type="button" @click="search">Search</button>
    </form>
    <div v-if="weatherData" class="result">
      <div class="row">
        <div class="col h2">
          {{ weatherData.main }}
        </div>
        <div class="col-auto">
          <div>
            <div>
              <label class="form-label">Temperature</label>
              <div class="h3">{{ weatherData.temperature }}</div>
            </div>
            <div>
              <label class="form-label">Feels like</label>
              <div class="h4">{{ weatherData.feelsLike }}</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
header {
  padding: 0;
}

form {
  max-width: 600px;
  margin: 10px auto;
}

.result {
  max-width: 600px;
  margin: 0 auto;
}
</style>
