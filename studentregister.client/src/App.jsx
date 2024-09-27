import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [students, setStudents] = useState([]);

    useEffect(() => {
        LoadStudents();
    }, []);

    const contents = students === undefined
        ? <p><em>Loading... Please refresh </em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Date of Birth</th>
                </tr>
            </thead>
            <tbody>
                {students.map((forecast) =>
                    <tr key={forecast.id}>
                        <td>{forecast.id}</td>
                        <td>{forecast.firstName}</td>
                        <td>{forecast.lastName}</td>
                        <td>{forecast.dateOfBirth}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Students</h1>
            {contents}
        </div>
    );
    
    async function LoadStudents() {
        const response = await fetch('/core/api/Students');
        const data = await response.json();
        setStudents(data);
    }
}

export default App;