import React, { useState, useEffect } from 'react';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';

const UpdateStudentModal = ({ show, handleClose, studentData, handleSave }) => {
    const [student, setStudent] = useState({
        firstName: '',
        lastName: '',
        dob: '',
        nationalityId: '',
        familyMembers: [],
    });

    // Initialize state with student data when modal opens
    useEffect(() => {
        if (studentData) {
            setStudent({ ...studentData });
        }
    }, [studentData]);

    // Handle input change for the main student information
    const handleChange = (e) => {
        const { name, value } = e.target;
        setStudent({ ...student, [name]: value });
    };

    // Handle family member input change
    const handleFamilyMemberChange = (index, e) => {
        const { name, value } = e.target;
        const updatedFamilyMembers = [...student.familyMembers];
        updatedFamilyMembers[index] = { ...updatedFamilyMembers[index], [name]: value };
        setStudent({ ...student, familyMembers: updatedFamilyMembers });
    };

    // Add a new family member
    const addFamilyMember = () => {
        setStudent({
            ...student,
            familyMembers: [
                ...student.familyMembers,
                { firstName: '', lastName: '', dob: '', nationalityId: '', relationId: '' },
            ],
        });
    };

    // Delete a family member
    const deleteFamilyMember = (index) => {
        const updatedFamilyMembers = student.familyMembers.filter((_, i) => i !== index);
        setStudent({ ...student, familyMembers: updatedFamilyMembers });
    };

    // Handle form submission
    const handleSubmit = (e) => {
        e.preventDefault();
        handleSave(student);
    };

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Update Student Information</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form onSubmit={handleSubmit}>
                    {/* Main Student Information */}
                    <Row className="mb-3">
                        <Col>
                            <Form.Group>
                                <Form.Label>First Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="firstName"
                                    value={student.firstName}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group>
                                <Form.Label>Last Name</Form.Label>
                                <Form.Control
                                    type="text"
                                    name="lastName"
                                    value={student.lastName}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row className="mb-3">
                        <Col>
                            <Form.Group>
                                <Form.Label>Date of Birth</Form.Label>
                                <Form.Control
                                    type="date"
                                    name="dob"
                                    value={student.dob}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group>
                                <Form.Label>Nationality ID</Form.Label>
                                <Form.Control
                                    type="number"
                                    name="nationalityId"
                                    value={student.nationalityId}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                        </Col>
                    </Row>

                    {/* Family Members Section */}
                    <h5>Family Members</h5>
                    {student.familyMembers.map((member, index) => (
                        <div key={index} className="mb-3 border p-3">
                            <Row>
                                <Col>
                                    <Form.Group>
                                        <Form.Label>First Name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="firstName"
                                            value={member.firstName}
                                            onChange={(e) => handleFamilyMemberChange(index, e)}
                                        />
                                    </Form.Group>
                                </Col>
                                <Col>
                                    <Form.Group>
                                        <Form.Label>Last Name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="lastName"
                                            value={member.lastName}
                                            onChange={(e) => handleFamilyMemberChange(index, e)}
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>
                            <Row>
                                <Col>
                                    <Form.Group>
                                        <Form.Label>Date of Birth</Form.Label>
                                        <Form.Control
                                            type="date"
                                            name="dob"
                                            value={member.dob}
                                            onChange={(e) => handleFamilyMemberChange(index, e)}
                                        />
                                    </Form.Group>
                                </Col>
                                <Col>
                                    <Form.Group>
                                        <Form.Label>Nationality ID</Form.Label>
                                        <Form.Control
                                            type="number"
                                            name="nationalityId"
                                            value={member.nationalityId}
                                            onChange={(e) => handleFamilyMemberChange(index, e)}
                                        />
                                    </Form.Group>
                                </Col>
                                <Col>
                                    <Form.Group>
                                        <Form.Label>Relation ID</Form.Label>
                                        <Form.Control
                                            type="number"
                                            name="relationId"
                                            value={member.relationId}
                                            onChange={(e) => handleFamilyMemberChange(index, e)}
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>
                            <Button
                                variant="danger"
                                className="mt-2"
                                onClick={() => deleteFamilyMember(index)}
                            >
                                Delete Family Member
                            </Button>
                        </div>
                    ))}
                    <Button variant="primary" onClick={addFamilyMember} className="mb-3">
                        Add Family Member
                    </Button>

                    {/* Modal Footer */}
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Close
                        </Button>
                        <Button variant="primary" type="submit">
                            Save Changes
                        </Button>
                    </Modal.Footer>
                </Form>
            </Modal.Body>
        </Modal>
    );
};

export default UpdateStudentModal;
