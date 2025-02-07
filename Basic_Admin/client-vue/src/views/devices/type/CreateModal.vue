<script lang="ts" setup>
import { ref, h, nextTick, reactive, onBeforeMount } from "vue";
import {
  VxeFormInstance,
  VxeFormPropTypes,
  VxeInput,
  VxeSelect
} from "vxe-pc-ui";
import { ReDictionary } from "@/components/ReDictionary";
import { getSingle, submitData } from "@/api/device/device";
import { getPageList } from "@/api/device/device";

const emits = defineEmits<{ (e: "reload"): void }>();
const vxeModalRef = ref();
const modalOptions = reactive<{
  modalValue: boolean;
  modalTitle: string;
  canSubmit: boolean;
}>({
  modalValue: false,
  modalTitle: "",
  canSubmit: true
});

const showModal = (title: string, canSubmit?: boolean): void => {
  modalOptions.modalTitle = title;
  modalOptions.modalValue = true;
  modalOptions.canSubmit = canSubmit ?? true;
};

interface AdddeviceTypeInput {
  deviceTypeId: string;
  name: string | null;
  remarks: string;
  class: string;
}
const formRef = ref<VxeFormInstance>();
const defaultFormData = () => {
  return {
    deviceTypeId: "",
    name: "",
    remarks: "",
    class: ""
  };
};
const assetUserOptions = ref<any[]>([]);
const formData = ref<AdddeviceTypeInput>(defaultFormData());
const formItems = ref<VxeFormPropTypes.Items>([
  {
    field: "deviceTypeId",
    title: "设备类型ID",
    span: 24,
    itemRender: {
      name: "$input",
      props: { placeholder: "请输入设备类型ID编号，相同类型不能重复" }
    }
  },
  {
    field: "name",
    title: "设备名称",
    span: 24,
    itemRender: {
      name: "$input",
      props: { placeholder: "请输入设备名称" }
    }
  },
  {
    field: "class",
    title: "设备类型",
    span: 24,
    slots: {
      default: ({ data }) => {
        return h(ReDictionary, {
          code: "dict_sensor_type",
          modelValue: data.class,
          placeholder: "请选设备类型",
          onChange({ value }) {
            data.class = value;
            formData.value.class = value;
          }
        });
      }
    }
  },
  {
    field: "remarks",
    title: "备注",
    span: 24,
    itemRender: {
      name: "$input",
      props: { placeholder: "请输备注" }
    }
  }
]);
const formRules = ref<VxeFormPropTypes.Rules>({
  deviceTypeId: [{ required: true, message: "请输入设备类型编号" }],
  name: [{ required: true, message: "请选择设备名称" }],
  class: [{ required: true, message: "请选择设备类型" }]
});

const showAddModal = () => {
  showModal(`添加设备类型`);
  debugger;
  formData.value = defaultFormData();
  nextTick(() => {
    formRef.value.clearValidate();
  });
};
const showEditModal = (record: Recordable) => {
  showModal(`编辑设备类型->${record.assetId}`);
  nextTick(() => {
    formRef.value.clearValidate();
    getSingle(record.id).then((data: any) => {
      formData.value = data;
      //formData.value.assetStatus = data.assetStatus.toString(); // 确保状态为字符串
    });
  });
};
const showViewModal = (record: Recordable) => {
  showModal(`查看设备类型->${record.assetId}`, false);
  nextTick(() => {
    formRef.value.clearValidate();
    getSingle(record.id).then((data: any) => {
      formData.value = data;
      //formData.value.assetStatus = data.assetStatus.toString(); // 确保状态为字符串
    });
  });
};
const handleSubmit = async () => {
  const validate = await formRef.value.validate();
  if (!validate) {
    submitData(formData.value).then(() => {
      modalOptions.modalValue = false;
      emits("reload");
    });
  }
};
onBeforeMount(() => {
  getPageList({ PageSize: 200 }).then((result: any) => {
    assetUserOptions.value = result.items.map((item: any) => ({
      value: item.id,
      label: item.name
    }));
  });
});

defineExpose({ showAddModal, showEditModal, showViewModal });
</script>
<template>
  <vxe-modal
    ref="vxeModalRef"
    v-model="modalOptions.modalValue"
    width="600"
    height="400"
    showFooter
    :title="modalOptions.modalTitle"
  >
    <template #default>
      <vxe-form
        ref="formRef"
        :data="formData"
        :items="formItems"
        :rules="formRules"
        :titleWidth="100"
        :titleColon="true"
        :titleAlign="`right`"
      />
    </template>
    <template #footer>
      <vxe-button content="关闭" @click="modalOptions.modalValue = false" />
      <vxe-button
        v-if="modalOptions.canSubmit"
        status="primary"
        content="确定"
        @click="handleSubmit"
      />
    </template>
  </vxe-modal>
</template>
