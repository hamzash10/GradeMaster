import axios from "axios";

const BASE_URL = 'https://localhost:7001/api/Auth';

export const login = (teacher) => {
    return axios.post(`${BASE_URL}/login`, teacher);
};


export const register = async (info) => {
    return await axios.post(`${BASE_URL}/register`, info)
};

export const logout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("loginTime");
    sessionStorage.removeItem("sessionToken");
};

export const isAuthenticated = () => {
    const token = localStorage.getItem("token");
    const loginTime = parseInt(localStorage.getItem("loginTime"));
    const isSessionActive = sessionStorage.getItem("sessionToken");
    return token && ((Date.now() - loginTime) < 30 * 60 * 1000 || isSessionActive)


};