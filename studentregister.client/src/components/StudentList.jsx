import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { fetchStudents } from '../features/StudentListSlice';
import Modal from 'react-modal';

const StudentList = () => {
    const dispatch = useDispatch();
    const students = useSelector((state) => state.students.students);
    const status = useSelector((state) => state.students.status);
    const error = useSelector((state) => state.students.error);

    const [selectedStudent, setSelectedStudent] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);

    const openModal = (student) => {
        setSelectedStudent(student);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setSelectedStudent(null);
        setIsModalOpen(false);
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
        <div>
            <h2>Student List</h2>
            <table className="table table-striped" aria-labelledby="tableLabel">
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
            </table>

            {/* Modal Component */}
            <Modal
                isOpen={isModalOpen}
                onRequestClose={closeModal}
                contentLabel="Student Details"
                style={{
                    content: {
                        top: '50%',
                        left: '50%',
                        right: 'auto',
                        bottom: 'auto',
                        marginRight: '-50%',
                        transform: 'translate(-50%, -50%)',
                    },
                }}
            >
                {selectedStudent && (
                    <div>
                        <h2>{ selectedStudent.firstName} {selectedStudent.lastName}</h2>
                        <p><strong>DOB:</strong> {selectedStudent.dateOfBirth}</p>
                        <button onClick={closeModal}>Close</button>
                    </div>
                )}
            </Modal>
        </div>
    );
}

export default StudentList;