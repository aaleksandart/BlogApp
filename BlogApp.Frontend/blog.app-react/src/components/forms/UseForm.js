import DOMPurify from 'dompurify';
import { useState, useEffect } from 'react';

const UseForm = (submitPost, formValidation) => {

    const [formValues, setFormValues] = useState({
        postTitle: '',
        postBody: '',
        imageUrl: '',
    });

    const [formErrors, setFormErrors] = useState({
        postTitle: '',
        postBody: '',
        imageUrl: '',
    });

    const [submitted, setSubmitted] = useState(false);

    const handleChange = (e) => {
        const { name, value } = e.target
        setFormValues({
            ...formValues,
            [name]: value
        });
        setSubmitted(false)
    };

    //Sanitizing input values
    const sanitizeFormValues = () => {
        formValues.postTitle = DOMPurify.sanitize(formValues.postTitle)
        formValues.postBody = DOMPurify.sanitize(formValues.postBody)
        formValues.imageUrl = DOMPurify.sanitize(formValues.imageUrl)
        console.log(formValues)
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        sanitizeFormValues()
        setFormErrors(formValidation(formValues));
        setSubmitted(true);
    }

    useEffect(() => {
        if (Object.keys(formErrors).length === 0 && submitted) {
            submitPost();
        }
    }, [submitted, formErrors, submitPost]);

    return { handleChange, handleSubmit, formValues, formErrors };
}

export default UseForm