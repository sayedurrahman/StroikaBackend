import { Container, Form, Button } from 'react-bootstrap';
import useStudentManagement from '../hooks/useStudentManagement';

const AddStudentForm = () => {
    const {
        firstName,
        lastName,
        dob,
        setFirstName,
        setLastName,
        setDob,
        handleAddStudentSubmit,
        handleReset,
        navigateToHome
    } = useStudentManagement();

    return (
        <Container className="mt-5">
            <h2>Add Student</h2>
            <Form onSubmit={handleAddStudentSubmit}>
                <Form.Group className="mb-3">
                    <Form.Label>First Name</Form.Label>
                    <Form.Control
                        required
                        type="text"
                        placeholder="Enter first name"
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Last Name</Form.Label>
                    <Form.Control
                        required
                        type="text"
                        placeholder="Enter last name"
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Date of Birth</Form.Label>
                    <Form.Control
                        type="date"
                        value={dob}
                        onChange={(e) => setDob(e.target.value)}
                    />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Add Student
                </Button>
                <Button variant="warning" className="ms-2" onClick={handleReset}>
                    Reset
                </Button>
                <Button variant="secondary" className="ms-2" onClick={navigateToHome}>
                    Cancel
                </Button>
            </Form>
        </Container>
    );
}

export default AddStudentForm;