import axios from "axios";

const BASE_URL = 'https://localhost:7001/api/Auth';

export const login = (teacher) => {
    return axios.post(`${BASE_URL}/login`, teacher);
};


export const register = async (info) => {
    return await axios.post(`${BASE_URL}/register`, info)
};

export const logout = () => {
    localStorage.removeItem('authToken');
};