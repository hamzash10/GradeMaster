import React, {useState, useEffect} from "react";
import TeachersApi from "../ApiCalls/TeachersApi";


//Component for doing Crud operation using server calls
function TeachersEditing(){

    //usestate creates the first initaliztion
    // state all teachers
    const [teachers, setTeachers] = useState([]);

    //state current teacher
    const [currentTeacher, setCurrentTeacher] = useState({
        id:0,
        email:'',
        password:'',
        firstName:'',
        lastName:'',
        phoneNumber:'',
        courses: []
    });


    // edit-create
    const [editing, setEditing] = useState(false);

    // useEffect: event for each state change
    // if empty its triggered only once
    useEffect(()=>{
        refreshTeachers()
    },[]);


    const handleInputChange = event => {
        const {name,value} = event.target;
        setCurrentTeacher({...currentTeacher,[name]:value});
    }

    //load al teachers from remote api
    const refreshTeachers = ()=>{
        // call api in server
        // and save it into state
        TeachersApi.getTeachers().then(response=>{
            setTeachers(response.data);
        });
    };

    const addTeacher = ()=>{
        //call server add
        TeachersApi.createTeacher(currentTeacher).then(response=>{
            //refresh current list
            refreshTeachers();
            //clean current teahcer
            setCurrentTeacher({
                id:0,
                email:'',
                password:'',
                firstName:'',
                lastName:'',
                phoneNumber:'',
                courses: []
            });
        });
    };

    const updateTeacher = ()=>{
        //call server add
        TeachersApi.updateTeacher(currentTeacher.id,currentTeacher).then(response=>{
            //refresh current list
            refreshTeachers();
            //clean current teahcer
            setCurrentTeacher({
                id:0,
                email:'',
                password:'',
                firstName:'',
                lastName:'',
                phoneNumber:'',
                courses: []
            });
            setEditing(false);
        });
    };


    const deleteTeacher = id =>{
        TeachersApi.deleteTeacher(id).then(()=>{
            refreshTeachers();
        });
    };

    const editTeacher = teacher =>{
        setCurrentTeacher(teacher);
        setEditing(true);
    };

    return(
        /*
        edit/create form
        list of all Teachers (each item will have delete btn and edit)

        */ 
        
        <div className="container">
            <h2>Teachers:</h2>
            <form onSubmit={event =>{
                    event.preventDefault();
                    editing ? updateTeacher() : addTeacher();
                }}
            >
                <div className="form-group">
                    <label>Email</label>
                    <input
                        type="email"
                        name="email"
                        value={currentTeacher.email}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label>password</label>
                    <input
                        type="password"
                        name="password"
                        value={currentTeacher.password}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label>firstName</label>
                    <input
                        type="text"
                        name="firstName"
                        value={currentTeacher.firstName}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label>lastName</label>
                    <input
                        type="text"
                        name="lastName"
                        value={currentTeacher.lastName}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>
                <div className="form-group">
                    <label>phoneNumber</label>
                    <input
                        type="text"
                        name="phoneNumber"
                        value={currentTeacher.phoneNumber}
                        onChange={handleInputChange}
                        className="form-control"
                    />
                </div>

                <button type="submit" className="btn btn-primary mt-2">
                    {editing ? "Update":"Add"}
                </button>

            </form>
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Email</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Phone Number</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {teachers.map(teacher => (
                        <tr key={teacher.id}>
                            <td>{teacher.email}</td>
                            <td>{teacher.firstName}</td>
                            <td>{teacher.lastName}</td>
                            <td>{teacher.phoneNumber}</td>
                            <td>
                                <button onClick={() => editTeacher(teacher)} className="btn btn-warning m-1">Edit</button>
                                <button onClick={() => deleteTeacher(teacher.id)} className="btn btn-danger m-1">Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>

        </div>

    )
}

export default TeachersEditing;