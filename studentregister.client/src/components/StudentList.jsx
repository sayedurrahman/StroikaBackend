import { Link } from 'react-router-dom';
import { Container, Button, Table } from 'react-bootstrap';
import UpdateStudentModal from './UpdateStudentModal';
import useStudentListManager from '../hooks/useStudentListManager';

const StudentList = () => {
    const {
        students,
        status,
        error,
        selectedStudent,
        isModalOpen,
        openModal,
        closeModal,
        saveStudent,
    } = useStudentListManager();

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
                    {students.map((student) => (
                        <tr key={student.id}
                            onClick={() => openModal(student)}
                            style={{ cursor: 'pointer', padding: '5px', border: '1px solid #ddd', margin: '5px 0' }}>
                            <td>{student.id}</td>
                            <td>{student.firstName}</td>
                            <td>{student.lastName}</td>
                            <td>{new Date(student.dateOfBirth).toISOString().split('T')[0]}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>

            <UpdateStudentModal
                show={isModalOpen}
                handleClose={closeModal}
                studentData={selectedStudent}
                handleSave={saveStudent}
            />
        </Container>
    );
};

export default StudentList;
