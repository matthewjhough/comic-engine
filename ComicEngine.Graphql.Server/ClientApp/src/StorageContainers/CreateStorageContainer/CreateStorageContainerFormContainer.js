import {toggleLoading} from "../../ComicResults/comicResultsActions";
import {connect} from "react-redux";
import {createStorageContainer} from "./createStorageContainerAction";
import {CreateStorageContainerForm} from "./CreateStorageContainerForm";


const mapStateToProps = ({ comicResults }) => ({ ...comicResults });

const mapDispatchToProps = dispatch => ({
    toggleLoading: isLoading => dispatch(toggleLoading(isLoading)),
    createStorageContainer: storageContainer => dispatch(createStorageContainer(storageContainer))
});

export const CreateStorageContainerFormContainer = connect(
    mapStateToProps,
    mapDispatchToProps
)(CreateStorageContainerForm);