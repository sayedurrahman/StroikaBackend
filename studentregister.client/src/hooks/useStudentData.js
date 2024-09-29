import { useState, useEffect } from 'react';
import { getStudentNationality, getStudentFamilyMembers } from '../apis/studentApi';

const useStudentData = (studentData) => {
    const [student, setStudent] = useState({
        firstName: '',
        lastName: '',
        dob: '',
        nationalityId: '',
        familyMembers: [],
    });

    // Initialize student data
    useEffect(() => {
        if (studentData) {
            setStudent({ ...studentData });
        }
    }, [studentData]);

    // Fetch nationality and family members
    useEffect(() => {
        if (studentData && studentData.id) {
            getStudentNationality(studentData.id).then(data => {
                setStudent(prevStudent => ({
                    ...prevStudent,
                    nationalityId: data.nationalityId
                }));
            });

            getStudentFamilyMembers(studentData.id).then(familyMembersData => {
                setStudent(prevStudent => ({
                    ...prevStudent,
                    familyMembers: familyMembersData
                }));
            });
        }
    }, [studentData]);

    // Handle input changes for student details
    const handleChange = (e) => {
        const { name, value } = e.target;
        setStudent(prevStudent => ({ ...prevStudent, [name]: value }));
    };

    // Handle family member changes
    const handleFamilyMemberChange = (index, e) => {
        const { name, value } = e.target;
        const updatedFamilyMembers = [...student.familyMembers];
        updatedFamilyMembers[index] = { ...updatedFamilyMembers[index], [name]: value };
        setStudent({ ...student, familyMembers: updatedFamilyMembers });
    };

    // Add a new family member
    const addFamilyMember = () => {
        setStudent(prevStudent => ({
            ...prevStudent,
            familyMembers: [
                ...(Array.isArray(prevStudent.familyMembers) ? prevStudent.familyMembers : []),
                { firstName: '', lastName: '', dob: '', nationalityId: '', relationId: '' },
            ],
        }));
    };

    // Delete a family member
    const deleteFamilyMember = (index) => {
        setStudent(prevStudent => ({
            ...prevStudent,
            familyMembers: prevStudent.familyMembers.filter((_, i) => i !== index),
        }));
    };

    return {
        student,
        handleChange,
        handleFamilyMemberChange,
        addFamilyMember,
        deleteFamilyMember,
    };
};

export default useStudentData;