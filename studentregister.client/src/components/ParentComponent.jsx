import React, { useState } from 'react';
import UpdateStudentModal from './UpdateStudentModal';
import { Container, Form, Button } from 'react-bootstrap';

const ParentComponent = () => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedStudent, setSelectedStudent] = useState(null);

    const handleOpenModal = (student) => {
        setSelectedStudent(student);
        setIsModalOpen(true);
    };

    const handleCloseModal = () => {
        setIsModalOpen(false);
        setSelectedStudent(null);
    };

    const handleSaveStudent = (updatedStudent) => {
        console.log('Updated Student:', updatedStudent);
        // Perform API call or state update logic here
        handleCloseModal();
    };

    // Example student data to be passed to modal
    const student = {
        firstName: 'John',
        lastName: 'Doe',
        dob: '2024-01-01',
        nationalityId: 1,
        familyMembers: [
            {
                firstName: 'Jane',
                lastName: 'Doe',
                dob: '2010-05-15',
                nationalityId: 2,
                relationId: 1,
            },
        ],
    };

    return (
        <div>
            <Button onClick={() => handleOpenModal(student)}>Edit Student</Button>

            <UpdateStudentModal
                show={isModalOpen}
                handleClose={handleCloseModal}
                studentData={selectedStudent}
                handleSave={handleSaveStudent}
            />
        </div>
    );
};

export default ParentComponent;
