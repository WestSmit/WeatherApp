<script>
import axios from 'axios'

export default {
  data() {
    return {
      requests: [],
    }
  },
  created() {
    console.log("created")
    this.getHistory()
  },
  methods: {
    async getHistory() {
      const results = await axios.get('http://localhost:5245/api/1/history');
      this.requests = results.data;
      console.log(this.requests)
    }
  }
}
</script>

<template>
  <div>
    <div v-for="(x, index) in requests" :key="index" class="card">
      <div>{{ x.dateTime }}</div>
      <div>{{ x.city }}</div>
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
