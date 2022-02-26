import axios from "axios";

axios.defaults.baseURL = "https://localhost:44316/";
axios.defaults.withCredentials = true;

export default axios;