import { useEffect, useState } from 'react';
import './App.css';
import UserRole from './components/UserRole';
import StudentList from './components/StudentList';
 
function App() {
    //const [students, setStudents] = useState([]);

    //useEffect(() => {
    //    LoadStudents();
    //}, []);

    //const contents = students === undefined
    //    ? <p><em>Loading... Please refresh </em></p>
    //    : <table className="table table-striped" aria-labelledby="tableLabel">
    //        <thead>
    //            <tr>
    //                <th>Id</th>
    //                <th>First Name</th>
    //                <th>Last Name</th>
    //                <th>Date of Birth</th>
    //            </tr>
    //        </thead>
    //        <tbody>
    //            {students.map((student) =>
    //                <tr key={student.id}>
    //                    <td>{student.id}</td>
    //                    <td>{student.firstName}</td>
    //                    <td>{student.lastName}</td>
    //                    <td>{student.dateOfBirth}</td>
    //                </tr>
    //            )}
    //        </tbody>
    //    </table>;

    return (
        <div>
            <UserRole />
            <StudentList />
              {/*{contents}*/}
        </div>
    );
    
    //async function LoadStudents() {
    //    const response = await fetch('/core/api/Students');
    //    const data = await response.json();
    //    setStudents(data);
    //}
}

export default App;