import React, { useEffect, useState } from 'react';
import { Container, Form, Button } from 'react-bootstrap';
import { useSelector, useDispatch } from 'react-redux';

const StudentForm = (props) => {
    const nationalities = useSelector((state) => state.nationalities.nationalities);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [dateOfBirth, setDob] = useState(new Date());
    const [nationalityId, setNationalityId] = useState(0);
    const dispatch = useDispatch();
    const student = props.studentData;
    //const role = useSelector((state) => state.userRole.role);

    const handleChange = (event) => {
        const selectedNationality = event.target.value;
        dispatch(setNationalityId(selectedNationality));
    };

    // Load student data when it becomes available
    useEffect(() => {
        if (student) {
            setFirstName(student.firstName || '');
            setLastName(student.lastName || '');
            setDob(student.dateOfBirth || new Date());
        }
    }, [student]);

    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault(); // Prevent page refresh

        // Create an object with the form data
        const formData = {
            firstName,
            lastName,
            dateOfBirth
        };

        //console.log(formData);

        // Call the onSubmit prop function with the form data
        //if (onSubmit) {
        //    onSubmit(formData);
        //}
    };

    return (
        <Container className="mt-5">
            <h2>Update Student</h2>
            <Form onSubmit={handleSubmit}>
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
                    <Form.Label>Date Of Birth</Form.Label>
                    <Form.Control
                        required
                        type="date"
                        value={dateOfBirth}
                        onChange={(e) => setDob(e.target.value)}
                    />
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Nationality</Form.Label>
                    <Form.Select aria-label="Default select example" value={nationalityId} onChange={handleChange}>
                        {nationalities.map((nationality) =>
                            <option key={nationality.Id} value={nationality.Id}>{nationality.name} {nationality.country}</option>
                        )}
                    </Form.Select>
                </Form.Group>

                <br />
                <button type="submit">Submit</button>
            </Form>
        </Container>
    );
}

export default StudentForm;