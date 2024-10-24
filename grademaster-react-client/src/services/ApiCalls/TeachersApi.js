import axios from 'axios'

//get this from the backend: properties -> launchSettings.json -> https -> applicationUrl
const API_TEACHERS_URL = 'https://localhost:7001/api/Teachers';

// REST API methods
class TeachersApi{

    // api/teachers
    getTeachers(){
        return axios.get(API_TEACHERS_URL);
    }

    // api/teachers/10
    getTeachersById(id){
        return axios.get(`${API_TEACHERS_URL}/${id}`);
    }

    // api/teachers
    // body: teacher JSON
    createTeacher(teacher){
        return axios.post(API_TEACHERS_URL,teacher);
    }

    // api/teachers/10
    // body: teacher JSON to update
    updateTeacher(id, teacher) {
        return axios.put(`${API_TEACHERS_URL}/${id}`, teacher);
    }

    // api/teachers/10
    deleteTeacher(id){
        return axios.delete(`${API_TEACHERS_URL}/${id}`);
    }
    
}

export default new TeachersApi();