import axios from "axios";

<<<<<<< HEAD
axios.defaults.baseURL = "https://localhost:44316/";
=======
axios.defaults.baseURL  ="https://localhost:44316";
>>>>>>> master
axios.defaults.withCredentials = true;
let getCookie = function (cookie) {
    let reg = /csrftoken=([\w]+)[;]?/g
    return reg.exec(cookie)[1]

}

export default axios;