import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { fetchStudents } from '../features/StudentListSlice';
import { Link } from 'react-router-dom';
import { Container, Button, Table } from 'react-bootstrap';
import UpdateStudentModal from './UpdateStudentModal';

const StudentList = () => {
    const dispatch = useDispatch();
    const students = useSelector((state) => state.students.students);
    const status = useSelector((state) => state.students.status);
    const error = useSelector((state) => state.students.error);

    const [selectedStudent, setSelectedStudent] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);
    
    //Modal.setAppElement('#root'); // To prevent screen readers from interacting with content outside the modal

    const openModal = (student) => {
        setSelectedStudent(student);
        setIsModalOpen(true);
    };

    const handleCloseModal = () => {
        setSelectedStudent(null);
        setIsModalOpen(false);
    };

    const handleSaveStudent = (updatedStudent) => {
        console.log('Updated Student:', updatedStudent);
        // Perform API call or state update logic here
        handleCloseModal();
    };

    // Fetch students data when the component mounts
    useEffect(() => {
        if (status === 'idle') {
            dispatch(fetchStudents());
        }
    }, [status, dispatch]);

    if (status === 'loading') {
        return <div>Loading...</div>;
    }

    if (status === 'failed') {
        return <div>Error: {error}</div>;
    }

    return (
        <Container className="mt-5">
            <Link to="/add-student">
                <Button variant="primary" className="mb-3">Add New Student</Button>
            </Link>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Date of Birth</th>
                    </tr>
                </thead>
                <tbody>
                    {students.map((student) =>
                        <tr key={student.id}
                            onClick={() => openModal(student)}
                            style={{ cursor: 'pointer', padding: '5px', border: '1px solid #ddd', margin: '5px 0' }} >
                            <td>{student.id}</td>
                            <td>{student.firstName}</td>
                            <td>{student.lastName}</td>
                            <td>{student.dateOfBirth}</td>
                        </tr>
                    )}
                </tbody>
            </Table>

            <UpdateStudentModal
                show={isModalOpen}
                handleClose={handleCloseModal}
                studentData={selectedStudent}
                handleSave={handleSaveStudent}
            />
        </Container>
    );
}

export default StudentList;